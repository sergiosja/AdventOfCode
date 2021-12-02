; Read input to list
(define (read-lines filename)
  (define (inner port)
    (let ((val (read port)))
      (if (eof-object? val)
        '()
        (cons val (inner port)))))
  (let* ((file (open-input-file filename)))
    (inner file)))


; Abstraction barrier
(define input (read-lines "input.txt"))
(define (dir lst) (car lst))
(define (dist lst) (cadr lst))


; Main algorithm
(define (solver lst)
  (define (iter depth pos aim lst)
    (cond ((null? lst) (list (* depth pos) (* aim pos)))
          ((eq? 'up (dir lst))
           (iter (- depth (dist lst)) pos aim (cddr lst)))
          ((eq? 'down (dir lst))
           (iter (+ depth (dist lst)) pos aim (cddr lst)))
          (else
           (iter depth (+ pos (dist lst))
                 (+ aim (* depth (dist lst))) (cddr lst)))))
  (iter 0 0 0 lst))

(solver input)