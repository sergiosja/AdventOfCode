(load "input.scm")

(define (filter pred lst)
  (cond ((null? lst) '())
        ((pred (car lst))
         (cons (car lst)
               (filter pred (cdr lst))))
        (else (filter pred (cdr lst)))))

(define (dir s)
  (lambda (x) (eq? x s)))


; Part 1
(define (solver lst)
  (- (length (filter (dir '\() lst))
     (length (filter (dir '\)) lst))))

(solver input)


; Part 2
(define (solver lst)
  (define (iter up down lst)
    (cond ((< up down) (+ up down))
          ((eq? '\( (car lst))
           (iter (+ 1 up) down (cdr lst)))
          (else (iter up (+ 1 down) (cdr lst)))))
  (iter 0 0 lst))

(solver input)