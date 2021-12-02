; Read input to list
(define (read-lines filename)
  (define (inner port)
    (let ((val (read port)))
      (if (eof-object? val)
        '()
        (cons val (inner port)))))
  (let* ((file (open-input-file filename)))
    (inner file)))


(define input (read-lines "input.txt"))

; Part 1
(define (solver lst)
  (if (null? (cdr lst))
      0
      (+ (if (< (car lst) (cadr lst)) 1 0)
         (solver (cdr lst)))))

(solver input)


; Part 2
(define (helper lst)
  (if (null? (cddr lst))
      '()
      (cons (+ (car lst) (cadr lst) (caddr lst))
            (helper (cdr lst)))))

(solver (helper input))